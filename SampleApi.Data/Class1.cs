using CMS.Framwork.Data.Framwork;

namespace SampleApi.Data
{
    public class Class1 : BaseModel
    {
        public string name { get; set; }
        public int age { get; set; }
        public string dateOfBirth { get; set; }

        public bool Validate()
        {
            return age > 18;
        }
    }
}
