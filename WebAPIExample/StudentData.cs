namespace StudentDataNamespace
{
    public class StudentDataClass
    {
        public int roll { get; set; }
        public string name { get; set; }

    }
    public class StudentDataListClass
    {
        public List<StudentDataClass> studentDataList { get; set; } = null;
        public StudentDataListClass()
        {
            studentDataList = new List<StudentDataClass>();
            StudentDataClass sd = new StudentDataClass();
            sd.roll = 101;
            sd.name = "Ashwin";
            studentDataList.Add(sd);

            sd = new StudentDataClass();
            sd.roll = 102;
            sd.name = "Piyush";
            studentDataList.Add(sd);

            sd = new StudentDataClass();
            sd.roll = 103;
            sd.name = "ABC";
            studentDataList.Add(sd);
        }
    }
}