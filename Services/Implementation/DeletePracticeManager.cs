using CommonUnitOfWork;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class DeletePracticeManager : IDeletePracticeManager
    {
        private IUnitOfWork _unitOfWork;
        public DeletePracticeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int DeletePracticeMaster(int id)
        {
            try
            {
                var result = _unitOfWork.DeletePracticeRepository.DeletePracticeMaster(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
