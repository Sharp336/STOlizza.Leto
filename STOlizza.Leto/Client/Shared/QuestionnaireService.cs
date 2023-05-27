using STOlizza.Leto.Shared;

namespace STOlizza.Leto.Client.Shared
{
    public interface IQuestionnaireService
    {
        QuestionnaireDTO Get();

        public void Set(QuestionnaireDTO _QDTO);
    }
    public class QuestionnaireService : IQuestionnaireService
    {
        public QuestionnaireService() { }
        public QuestionnaireDTO QDTO { get; set; } = new();
        public QuestionnaireDTO Get() => QDTO;

        public void Set(QuestionnaireDTO _QDTO)
        {
            QDTO = _QDTO;
        }
    }
}
