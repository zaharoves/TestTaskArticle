using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using TestTaskArticles.Models;

namespace TestTaskArticles.Controllers
{
    public class ArticlesController : Controller
    {
        /// <summary>
        /// Формирует страницу со всеми статьями
        /// </summary>
        /// <returns>Вид всех статей</returns>
        [CustomExceptionHandler]
        public ActionResult Index()
        {
            IEnumerable<ArticlesModel> articleModelList = DapperORM.ReturnList<ArticlesModel>("GetAllArticles", null);
            return View(articleModelList);
        }

        /// <summary>
        /// Формирует страницу статьи с комметариями 
        /// </summary>
        /// <param name="id">id статьи</param>
        /// <returns>Вид статьи с комментариями</returns>
        [CustomExceptionHandler]
        [HttpGet]
        public ActionResult ArticleDetails(int id)
        {
            if (id == 0)
                throw new ArgumentException($"Невозможно открыть статью с id=0 для чтения");

            DynamicParameters articleParam = new DynamicParameters();
            articleParam.Add("@ArticleId", id);
            ArticlesModel articleModel = DapperORM.ReturnList<ArticlesModel>("GetArticleById", articleParam).FirstOrDefault<ArticlesModel>();

            if (articleModel == null)
                throw new ArgumentException($"Не удалось найти статью с id={id} в базе данных");

            DynamicParameters commentParam = new DynamicParameters();
            commentParam.Add("@ArticleId", id);
            List<CommentsModel> commentsModelList = DapperORM.ReturnList<CommentsModel>("GetCommentsByArticleId", commentParam).ToList();

            foreach (CommentsModel commentModel in commentsModelList)
                RecursiveAddChildComments(articleModel.Id, commentModel);

            articleModel.Comments = commentsModelList;
            return View(articleModel);
        }

        /// <summary>
        /// Добавляет в модель комментария дочерние комментарии 
        /// </summary>
        /// <param name="articleId">id статьи, к которому относится комментарий</param>
        /// <param name="commentModel">модель комментария</param>
        [CustomExceptionHandler]
        private void RecursiveAddChildComments(int articleId, CommentsModel commentModel)
        {
            if (commentModel == null)
                throw new ArgumentNullException("В качестве модели комментария в метод для добавления дочерних комментариев передан null");

            DynamicParameters commentParam = new DynamicParameters();
            commentParam.Add("@ArticleId", articleId);
            commentParam.Add("@CommentId", commentModel.Id);

            List<CommentsModel> childCommentsModelList = DapperORM.ReturnList<CommentsModel>("GetChildComments", commentParam).ToList();

            if (childCommentsModelList.Count != 0)
            {
                commentModel.ChildComments = childCommentsModelList;
                foreach (CommentsModel childComment in commentModel.ChildComments)
                    RecursiveAddChildComments(articleId, childComment);
            }
        }

        /// <summary>
        /// Формирует страницу добавления комметария
        /// </summary>
        /// <param name="articleId">id статьи, к которому относится комметарий</param>
        /// <param name="parentId">id родительского комментария, если он есть</param>
        /// <returns>Вид страницы добавления комметария</returns>
        [CustomExceptionHandler]
        [HttpGet]
        public ActionResult AddComment(int articleId, int parentId)
        {
            if (!CheckArticleId(articleId))
                throw new ArgumentException($"Не найдена статья с Id={articleId} в базе данных");

            if (ModelState.IsValid)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add(@"ArticleId", articleId);

                ArticlesModel articleModel = DapperORM.ReturnList<ArticlesModel>("GetArticleById", param).FirstOrDefault<ArticlesModel>();
                CommentsModel commentsModel = new CommentsModel();

                commentsModel.ArticleId = articleModel.Id;
                commentsModel.ArticleText = articleModel.Text;
                commentsModel.ParentId = parentId;
              
                return View(commentsModel);
            }
            return View();
        }

        /// <summary>
        /// Добавляет комментарий к статье
        /// </summary>
        /// <param name="commentsModel">Модель комментария</param>
        /// <returns>Перенаправляет на вид статьи, к которой был отправлен комментарий</returns>
        [CustomExceptionHandler]
        [HttpPost]
        public ActionResult AddComment(CommentsModel commentsModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(@"ArticleId", commentsModel.ArticleId);

            if (commentsModel.ParentId == 0)
                param.Add(@"ParentCommentId", null);
            else
                param.Add(@"ParentCommentId", commentsModel.ParentId);

            param.Add(@"UserId", commentsModel.UserId);
            param.Add(@"Text", commentsModel.Text);

            DapperORM.Execute("AddComment", param);

            return RedirectToAction("ArticleDetails", new { id = commentsModel.ArticleId });
        }

        /// <summary>
        /// Проверяет, если ли пользователь с таким id в БД
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <returns>Возвращает true, если пользователь с таким id есть в БД. Иначе false</returns>
        [CustomExceptionHandler]
        [AcceptVerbs("GET", "POST")]
        public ActionResult CheckUserId(int userId)
        {
            DynamicParameters param = new DynamicParameters();
            List<UsersModel> usersModelList = DapperORM.ReturnList<UsersModel>("GetAllUsers", param).ToList();

            bool isSuccess = false;

            foreach (UsersModel userModel in usersModelList)
            {
                if (userModel.Id == userId)
                {
                    isSuccess = true;
                    break;
                }
            }

            return Json(isSuccess);
        }

        /// <summary>
        /// Проверяет, если ли статья с таким id в БД
        /// </summary>
        /// <param name="id">id статьи</param>
        /// <returns>Возвращает true, если статья с таким id есть в БД. Иначе false</returns>
        [CustomExceptionHandler]
        private bool CheckArticleId(int id)
        {
            DynamicParameters param = new DynamicParameters();
            List<ArticlesModel> articlesModelList = DapperORM.ReturnList<ArticlesModel>("GetAllArticles", param).ToList();

            bool isSuccess = false;

            foreach (ArticlesModel articleModel in articlesModelList)
            {
                if (articleModel.Id == id)
                {
                    isSuccess = true;
                    break;
                }                   
            }

            return isSuccess;
        }
    }
}