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
    public class EfCoreExamAswerRepository : EfCoreGenericRepository<ExamAnswers, AcademyContext>, IExamAnswerDal
    {
        public void Create(ExamAnswers entity, int questionId, int? optionId)
        {
            using (var _context = new AcademyContext())
            {
                entity.QuestionId = questionId;
                entity.OptionId = optionId;
                // "questionId" değeri "entity" nesnesinin "QuestionId" özelliğine atanır.
                _context.ExamAnswers.Add(entity);
                _context.SaveChanges();
            }
        }
    }
}
