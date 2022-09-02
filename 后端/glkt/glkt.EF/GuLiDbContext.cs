using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace glkt.EF
{
    public partial class GuLiDbContext : DbContext
    {
        public GuLiDbContext()
        {
        }

        public GuLiDbContext(DbContextOptions<GuLiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EduChapter> EduChapters { get; set; } = null!;
        public virtual DbSet<EduComment> EduComments { get; set; } = null!;
        public virtual DbSet<EduCourse> EduCourses { get; set; } = null!;
        public virtual DbSet<EduCourseCollect> EduCourseCollects { get; set; } = null!;
        public virtual DbSet<EduCourseDescription> EduCourseDescriptions { get; set; } = null!;
        public virtual DbSet<EduSubject> EduSubjects { get; set; } = null!;
        public virtual DbSet<EduTeacher> EduTeachers { get; set; } = null!;
        public virtual DbSet<EduVideo> EduVideos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=guli;username=root;password=123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.38-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<EduChapter>(entity =>
            {
                entity.ToTable("edu_chapter");

                entity.HasComment("课程")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                

                entity.HasIndex(e => e.CourseId, "idx_course_id");

                entity.Property(e => e.Id)
                    .HasMaxLength(19)
                    .HasColumnName("id")
                    .IsFixedLength()
                    .HasComment("章节ID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(19)
                    .HasColumnName("course_id")
                    .IsFixedLength()
                    .HasComment("课程ID");

                entity.Property(e => e.GmtCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_create")
                    .HasComment("创建时间");

                entity.Property(e => e.GmtModified)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_modified")
                    .HasComment("更新时间");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("sort")
                    .HasComment("显示排序");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .HasComment("章节名称");
            });

            modelBuilder.Entity<EduComment>(entity =>
            {
                entity.ToTable("edu_comment");

                entity.HasComment("评论")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                // 软删除
                entity.HasQueryFilter(e => e.IsDeleted == 0);

                entity.HasIndex(e => e.CourseId, "idx_course_id");

                entity.HasIndex(e => e.MemberId, "idx_member_id");

                entity.HasIndex(e => e.TeacherId, "idx_teacher_id");

                entity.Property(e => e.Id)
                    .HasMaxLength(19)
                    .HasColumnName("id")
                    .IsFixedLength()
                    .HasComment("讲师ID");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .HasColumnName("avatar")
                    .HasComment("会员头像");

                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .HasColumnName("content")
                    .HasComment("评论内容");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(19)
                    .HasColumnName("course_id")
                    .HasDefaultValueSql("''")
                    .HasComment("课程id");

                entity.Property(e => e.GmtCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_create")
                    .HasComment("创建时间");

                entity.Property(e => e.GmtModified)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_modified")
                    .HasComment("更新时间");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("tinyint(1) unsigned")
                    .HasColumnName("is_deleted")
                    .HasComment("逻辑删除 1（true）已删除， 0（false）未删除");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(19)
                    .HasColumnName("member_id")
                    .HasDefaultValueSql("''")
                    .HasComment("会员id");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .HasColumnName("nickname")
                    .HasComment("会员昵称");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(19)
                    .HasColumnName("teacher_id")
                    .HasDefaultValueSql("''")
                    .IsFixedLength()
                    .HasComment("讲师id");
            });

            modelBuilder.Entity<EduCourse>(entity =>
            {
                entity.ToTable("edu_course");

                entity.HasComment("课程")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                // 软删除
                entity.HasQueryFilter(e => e.IsDeleted == 0);

                entity.HasIndex(e => e.SubjectId, "idx_subject_id");

                entity.HasIndex(e => e.TeacherId, "idx_teacher_id");

                entity.HasIndex(e => e.Title, "idx_title");

                entity.Property(e => e.Id)
                    .HasMaxLength(19)
                    .HasColumnName("id")
                    .IsFixedLength()
                    .HasComment("课程ID");

                entity.Property(e => e.BuyCount)
                    .HasColumnType("bigint(10) unsigned")
                    .HasColumnName("buy_count")
                    .HasComment("销售数量");

                entity.Property(e => e.Cover)
                    .HasMaxLength(255)
                    .HasColumnName("cover")
                    .HasComment("课程封面图片路径")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.GmtCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_create")
                    .HasComment("创建时间");

                entity.Property(e => e.GmtModified)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_modified")
                    .HasComment("更新时间");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("is_deleted")
                    .HasComment("逻辑删除 1（true）已删除， 0（false）未删除");

                entity.Property(e => e.LessonNum)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("lesson_num")
                    .HasComment("总课时");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10,2) unsigned")
                    .HasColumnName("price")
                    .HasComment("课程销售价格，设置为0则可免费观看");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Draft'")
                    .HasComment("课程状态 Draft未发布  Normal已发布");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(19)
                    .HasColumnName("subject_id")
                    .IsFixedLength()
                    .HasComment("课程专业ID");

                entity.Property(e => e.SubjectParentId)
                    .HasMaxLength(19)
                    .HasColumnName("subject_parent_id")
                    .IsFixedLength()
                    .HasComment("课程专业父级ID");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(19)
                    .HasColumnName("teacher_id")
                    .IsFixedLength()
                    .HasComment("课程讲师ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .HasComment("课程标题");

                entity.Property(e => e.Version)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("version")
                    .HasDefaultValueSql("'1'")
                    .HasComment("乐观锁");

                entity.Property(e => e.ViewCount)
                    .HasColumnType("bigint(10) unsigned")
                    .HasColumnName("view_count")
                    .HasComment("浏览数量");
            });

            modelBuilder.Entity<EduCourseCollect>(entity =>
            {
                entity.ToTable("edu_course_collect");

                entity.HasComment("课程收藏")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                // 软删除
                entity.HasQueryFilter(e => e.IsDeleted == 0);

                entity.Property(e => e.Id)
                    .HasMaxLength(19)
                    .HasColumnName("id")
                    .IsFixedLength()
                    .HasComment("收藏ID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(19)
                    .HasColumnName("course_id")
                    .IsFixedLength()
                    .HasComment("课程讲师ID");

                entity.Property(e => e.GmtCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_create")
                    .HasComment("创建时间");

                entity.Property(e => e.GmtModified)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_modified")
                    .HasComment("更新时间");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("is_deleted")
                    .HasComment("逻辑删除 1（true）已删除， 0（false）未删除");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(19)
                    .HasColumnName("member_id")
                    .HasDefaultValueSql("''")
                    .IsFixedLength()
                    .HasComment("课程专业ID");
            });

            modelBuilder.Entity<EduCourseDescription>(entity =>
            {
                entity.ToTable("edu_course_description");

                entity.HasComment("课程简介")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");


                entity.Property(e => e.Id)
                    .HasMaxLength(19)
                    .HasColumnName("id")
                    .IsFixedLength()
                    .HasComment("课程ID");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasComment("课程简介");

                entity.Property(e => e.GmtCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_create")
                    .HasComment("创建时间");

                entity.Property(e => e.GmtModified)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_modified")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<EduSubject>(entity =>
            {
                entity.ToTable("edu_subject");

                entity.HasComment("课程科目")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");


                entity.HasIndex(e => e.ParentId, "idx_parent_id");

                entity.Property(e => e.Id)
                    .HasMaxLength(19)
                    .HasColumnName("id")
                    .IsFixedLength()
                    .HasComment("课程类别ID");

                entity.Property(e => e.GmtCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_create")
                    .HasComment("创建时间");

                entity.Property(e => e.GmtModified)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_modified")
                    .HasComment("更新时间");

                entity.Property(e => e.ParentId)
                    .HasMaxLength(19)
                    .HasColumnName("parent_id")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength()
                    .HasComment("父ID");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("sort")
                    .HasComment("排序字段");

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .HasColumnName("title")
                    .HasComment("类别名称");
            });

            modelBuilder.Entity<EduTeacher>(entity =>
            {
                entity.ToTable("edu_teacher");

                entity.HasComment("讲师")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                // 软删除
                entity.HasQueryFilter(e => e.IsDeleted == 0);

                entity.HasIndex(e => e.Name, "uk_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(19)
                    .HasColumnName("id")
                    .IsFixedLength()
                    .HasComment("讲师ID");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .HasColumnName("avatar")
                    .HasComment("讲师头像");

                entity.Property(e => e.Career)
                    .HasMaxLength(500)
                    .HasColumnName("career")
                    .HasComment("讲师资历,一句话说明讲师");

                entity.Property(e => e.GmtCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_create")
                    .HasComment("创建时间");

                entity.Property(e => e.GmtModified)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_modified")
                    .HasComment("更新时间");

                entity.Property(e => e.Intro)
                    .HasMaxLength(500)
                    .HasColumnName("intro")
                    .HasDefaultValueSql("''")
                    .HasComment("讲师简介");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("tinyint(1) unsigned")
                    .HasColumnName("is_deleted")
                    .HasComment("逻辑删除 1（true）已删除， 0（false）未删除");

                entity.Property(e => e.Level)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("level")
                    .HasComment("头衔 1高级讲师 2首席讲师");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasComment("讲师姓名");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("sort")
                    .HasComment("排序");
            });

            modelBuilder.Entity<EduVideo>(entity =>
            {
                entity.ToTable("edu_video");

                entity.HasComment("课程视频")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");


                entity.HasIndex(e => e.ChapterId, "idx_chapter_id");

                entity.HasIndex(e => e.CourseId, "idx_course_id");

                entity.Property(e => e.Id)
                    .HasMaxLength(19)
                    .HasColumnName("id")
                    .IsFixedLength()
                    .HasComment("视频ID");

                entity.Property(e => e.ChapterId)
                    .HasMaxLength(19)
                    .HasColumnName("chapter_id")
                    .IsFixedLength()
                    .HasComment("章节ID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(19)
                    .HasColumnName("course_id")
                    .IsFixedLength()
                    .HasComment("课程ID");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasComment("视频时长（秒）");

                entity.Property(e => e.GmtCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_create")
                    .HasComment("创建时间");

                entity.Property(e => e.GmtModified)
                    .HasColumnType("datetime")
                    .HasColumnName("gmt_modified")
                    .HasComment("更新时间");

                entity.Property(e => e.IsFree)
                    .HasColumnType("tinyint(1) unsigned")
                    .HasColumnName("is_free")
                    .HasComment("是否可以试听：0收费 1免费");

                entity.Property(e => e.PlayCount)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("play_count")
                    .HasComment("播放次数");

                entity.Property(e => e.Size)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("size")
                    .HasComment("视频源文件大小（字节）");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("sort")
                    .HasComment("排序字段");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Empty'")
                    .HasComment("Empty未上传 Transcoding转码中  Normal正常");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .HasComment("节点名称");

                entity.Property(e => e.Version)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("version")
                    .HasDefaultValueSql("'1'")
                    .HasComment("乐观锁");

                entity.Property(e => e.VideoOriginalName)
                    .HasMaxLength(100)
                    .HasColumnName("video_original_name")
                    .HasComment("原始文件名称");

                entity.Property(e => e.VideoSourceId)
                    .HasMaxLength(100)
                    .HasColumnName("video_source_id")
                    .HasComment("云端视频资源");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
