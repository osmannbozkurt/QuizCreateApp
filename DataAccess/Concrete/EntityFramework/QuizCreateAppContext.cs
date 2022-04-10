using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Concrete; 

namespace DataAccess.Concrete.EntityFramework
{
    public class QuizCreateAppContext : DbContext
    {
        private string _connString;
        public QuizCreateAppContext()
        { 
            _connString = DatabaseAssets.GetConnectionString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_connString);
                base.OnConfiguring(optionsBuilder);
            }
        } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Quiz> Quizs { get; set; } 
        public DbSet<Quiz_Question> Quiz_Questions { get; set; } 
        public DbSet<Quiz_Question_Option> Quiz_Question_Options { get; set; } 
    }
}
