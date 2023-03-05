using BusinessLayer.GenericService;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IExamQuestionService:IGenericService<ExamQuestions>
	{
		void Create(ExamQuestions entity, int questionId);

        List<ExamQuestions> GetQuestionsList();
        void DeleteFormExamQuestion(ExamQuestions entity, int questionId);
	}
}
