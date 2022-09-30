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
    public class ChapterRepository : RepositoryBase<EduChapter>, IChapterRepository
    {
        private readonly GuLiDbContext dbContext;

        public ChapterRepository(GuLiDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
