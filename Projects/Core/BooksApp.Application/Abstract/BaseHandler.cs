using BooksApp.Application.Interfaces.Repositories;

namespace BooksApp.Application.Abstract
{
    public abstract class BaseHandler
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
