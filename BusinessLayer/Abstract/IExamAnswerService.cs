using BusinessLayer.GenericService;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IExamAnswerService:IGenericService<ExamAnswers>
	{
        void Create(ExamAnswers entity, int questionId, int? optionId);
    }
}
