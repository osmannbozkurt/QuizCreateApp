using Autofac;
using Autofac.Extras.DynamicProxy;
using Businness.Managers;
using Businness.Services;
using Castle.DynamicProxy; 
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Businness.DependencyInjection.Autofac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {



            builder.RegisterType<BlogServiceManager>().As<IBlogSelectService>().SingleInstance(); 
            builder.RegisterType<QuizManager>().As<IQuizService>().SingleInstance(); 
            builder.RegisterType<QuizQuestionManager>().As<IQuizQuestionService>().SingleInstance(); 
            builder.RegisterType<QuizQuestionOptionManager>().As<IQuizQuestionOptionService>().SingleInstance();
            builder.RegisterType<AccountManager>().As<IAccountService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<ExamManager>().As<IExamService>().SingleInstance();

            builder.RegisterType<EfQuizDal>().As<IQuizDal>().SingleInstance(); 
            builder.RegisterType<EfQuiz_QuestionDal>().As<IQuiz_QuestionDal>().SingleInstance(); 
            builder.RegisterType<EfQuiz_Question_OptionDal>().As<IQuiz_Question_OptionDal>().SingleInstance(); 
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance(); 
    
             

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
