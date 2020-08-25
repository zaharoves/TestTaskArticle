using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace TestTaskArticles.Controllers
{
    /// <summary>
    /// Класс для обработки исключения и вывода информации об ошибке клиенту
    /// </summary>
    public class CustomExceptionHandler: Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;
            context.Result = new ContentResult
            {
                Content = $"Возникла ошибка!\n" +
                $"В методе: {actionName}\n" +
                $"Текст ошибки: {exceptionMessage}\n\n" +
                $"Стек ошибки:\n{exceptionStack}"
            };
            context.ExceptionHandled = true;
        }
    }
}
