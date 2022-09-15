using ggkt.Repository.Base;
using glkt.EF;
using glkt.IRepository.Edu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Repository.Edu
{
    public class SubjectRepository : RepositoryBase<EduSubject>, ISubjectRepository
    {
        private readonly GuLiDbContext _dbContext;

        public SubjectRepository(GuLiDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
