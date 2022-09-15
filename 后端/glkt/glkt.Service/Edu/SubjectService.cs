using glkt.EF;
using glkt.IRepository.Edu;
using glkt.IService.Edu;
using glkt.Model.VO.Edu;
using glkt.Model.VO.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace glkt.Service.Edu
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        /// <summary>
        /// 嵌套数据列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<EduSubjectNestedResponse>> NestedList()
        {
            // 一级分类
            var oneSubjectsList = await _subjectRepository.GetAllAsync().Where(s=>s.ParentId=="0").ToListAsync();
            // 二级分类
            var twoSubjectsList = await _subjectRepository.GetAllAsync().Where(s => s.ParentId != "0").ToListAsync();

            List<EduSubjectNestedResponse> list = new List<EduSubjectNestedResponse>();

            // 遍历一级分类
            foreach (var oneSubjects in oneSubjectsList)
            {
                List<EduSubjectNestedResponse> childrenList = new List<EduSubjectNestedResponse>();

                // 遍历二级分类
                foreach (var twoSubjects in twoSubjectsList)
                {
                    // 判断该二级分类属不属于这个一级分类
                    if (oneSubjects.Id==twoSubjects.ParentId)
                    {
                        childrenList.Add(new EduSubjectNestedResponse { 
                            Id=twoSubjects.Id,
                            Title=twoSubjects.Title
                        });
                    }
                }

                list.Add(new EduSubjectNestedResponse() { 
                    Id=oneSubjects.Id,
                    Title=oneSubjects.Title,
                    Children= childrenList
                });
            }

            return list;
        }


        /// <summary>
        /// 批量导入
        /// </summary>
        /// <param name="file"></param>
        public async Task BatchImport(IFormFile file)
        {
            // 读取Excel文件的内容
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            var rows = stream.Query<SubjectData>().ToList();

            // 存放已经存在的一级分类
            IDictionary<string,string> oneSudjectDictionary = new Dictionary<string,string>();

            for (int i = 0; i < rows.Count; i++)
            {
                // 每次查询一级分类的Id之前，先oneSudjectDictionary中是否存在一级分类的Id；
                // 若存在就不用再去查询数据库了
                if (!oneSudjectDictionary.ContainsKey(rows[i].OneSudjectName))
                {
                    string oneSudjectId = "";
                    EduSubject oneSubject = await GetOneSudject(rows[i].OneSudjectName);
                    if (oneSubject==null)// 判断是否存在该一级分类
                    {
                        // 若不存在，添加该分类
                        oneSudjectId = AddOneSudject(rows[i].OneSudjectName);
                    }
                    else
                    {
                        // 若存在，则查询该分类
                        oneSubject = await _subjectRepository.GetEntityAsync(s => s.Title == rows[i].OneSudjectName);
                        oneSudjectId = oneSubject.Id;
                    }
                    oneSudjectDictionary.Add(rows[i].OneSudjectName, oneSudjectId);
                }

                // 拿到最大的Sort，在它的基础上加一，就是新Sudject对象的sort属性
                uint sort = _subjectRepository.GetAllAsync().Where(s=>s.ParentId!="0").Max(s => s.Sort) + 1;

                EduSubject subject = new EduSubject() {
                    Id = Guid.NewGuid().ToString().Replace("-", ""),
                    ParentId = oneSudjectDictionary[rows[i].OneSudjectName],
                    Sort = sort,
                    Title = rows[i].TwoSudjectName,
                    GmtCreate=DateTime.Now,
                    GmtModified=DateTime.Now
                };

                _subjectRepository.Add(subject);
 
            }

            // 统一保存
            await _subjectRepository.SaveAsync();

        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="oneSudjectName">一级分类的名称</param>
        /// <returns></returns>
        private string AddOneSudject(string oneSudjectName)
        {
            // 拿到最大的Sort，在它的基础上加一，就是新Sudject对象的sort属性
            uint sort = _subjectRepository.GetAllAsync().Where(s=>s.ParentId=="0").Max(s => s.Sort) + 1;

            EduSubject subject = new EduSubject() {
                Id = Guid.NewGuid().ToString().Replace("-", ""),
                ParentId = "0",
                Sort = sort,
                Title = oneSudjectName,
                GmtCreate = DateTime.Now,
                GmtModified=DateTime.Now
            };

            _subjectRepository.Add(subject);

            return subject.Id;
            
        }

        /// <summary>
        /// 一级类别
        /// </summary>
        /// <param name="oneSudject"></param>
        /// <returns></returns>
        private async Task<EduSubject> GetOneSudject(string oneSudject)
        {
            EduSubject subject = await _subjectRepository.GetEntityAsync(s => s.Title == oneSudject);

            return subject;
        }

    }
}
