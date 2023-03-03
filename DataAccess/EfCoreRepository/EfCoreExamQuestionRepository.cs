using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EfCoreRepository
{
	public class EfCoreExamQuestionRepository : EfCoreGenericRepository<ExamQuestions, AcademyContext>, IExamQuestionDal
	{
		public void Create(ExamQuestions entity, int questionId)
		{
			throw new NotImplementedException();
		}

		public void DeleteFromExamQuestion(ExamQuestions entity, int questionId)
		{
			throw new NotImplementedException();
		}

	}
}
