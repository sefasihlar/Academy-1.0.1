using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IExamQuestionDal:IGenericDal<ExamQuestions>
	{
		void Create(ExamQuestions entity, int questionId);
		void DeleteFromExamQuestion(ExamQuestions entity, int questionId);
	}
}
