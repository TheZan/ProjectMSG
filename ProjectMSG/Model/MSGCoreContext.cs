using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectMSG.Model
{
    public partial class MSGCoreContext : DbContext
    {
        public MSGCoreContext()
        {
        }

        public MSGCoreContext(DbContextOptions<MSGCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<CorrectAnswer> CorrectAnswer { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("data source=DESKTOP-9MAURET\\SQLEXPRESS;initial catalog=MSGCore;persist security info=True;user id=MSGCore;password=test;MultipleActiveResultSets=True");
                optionsBuilder.UseSqlServer("data source=tcp:zan.database.windows.net,1433;initial catalog=MSGCore;persist security info=True;user id=Zan;password=41velimI;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answer");

                entity.Property(e => e.AnswerId).HasColumnName("answerId");

                entity.Property(e => e.AnswerText)
                    .IsRequired()
                    .HasColumnName("answerText");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_answer_question");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.ArticleName)
                    .IsRequired()
                    .HasColumnName("articleName");

                entity.Property(e => e.ArticleText)
                    .IsRequired()
                    .HasColumnName("articleText");

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_article_section");
            });

            modelBuilder.Entity<CorrectAnswer>(entity =>
            {
                entity.ToTable("correctAnswer");

                entity.Property(e => e.CorrectAnswerId).HasColumnName("correctAnswerId");

                entity.Property(e => e.AnswerId).HasColumnName("answerId");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.CorrectAnswer)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_correctAnswer_answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.CorrectAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_correctAnswer_question");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.ArticlePhotoId);

                entity.ToTable("photo");

                entity.Property(e => e.ArticlePhotoId).HasColumnName("articlePhotoId");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.ArticlePhoto)
                    .IsRequired()
                    .HasColumnName("articlePhoto");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_photo_article");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.Property(e => e.QuestionText)
                    .IsRequired()
                    .HasColumnName("questionText");

                entity.Property(e => e.TestId).HasColumnName("testId");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_question_test");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("result");

                entity.Property(e => e.ResultId).HasColumnName("resultId");

                entity.Property(e => e.TestId).HasColumnName("testId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_result_test");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_result_users");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasColumnName("sectionName");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.TestId).HasColumnName("testId");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasColumnName("testName");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_test_article");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(100);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
