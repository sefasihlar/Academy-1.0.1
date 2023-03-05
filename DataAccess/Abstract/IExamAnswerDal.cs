﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IExamAnswerDal:IGenericDal<ExamAnswers>
	{
        void Create(ExamAnswers entity, int questionId, int? optionIds);
    }
}
