using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
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

            using (var _context = new AcademyContext())
            {
                entity.QuestionId = questionId; // "questionId" değeri "entity" nesnesinin "QuestionId" özelliğine atanır.
               _context.ExamQuestions.Add(entity);
               _context.SaveChanges();
            }

          
        }

        public void DeleteFromExamQuestion(ExamQuestions entity, int questionId)
		{
			throw new NotImplementedException();
		}

        public List<ExamQuestions> GetQuestionsList()
        {
            using (var _context = new AcademyContext())
            {
                return _context.ExamQuestions
                    .Include(x=>x.Question)
                    .ThenInclude(x=>x.Options)
                    .Include(x=>x.Exam)
                    .ToList();
            }
        }
    }
}
