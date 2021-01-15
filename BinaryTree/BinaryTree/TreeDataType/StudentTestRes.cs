using System;
using System.Runtime.Serialization;

namespace BinaryTree.TreeDataType
{
    [DataContract]
    public class StudentTestRes : IComparable
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public StudentTestRes()
        {
            studentName = null;
            testName = null;
            dateOfPass = null;
            result = 0;
        }

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="studentName">Student name</param>
        /// <param name="testName">Test name</param>
        /// <param name="dateOfPass">Date of delivery</param>
        /// <param name="result">Test result</param>
        public StudentTestRes(string studentName, string testName, string dateOfPass, int result)
        {
            this.studentName = studentName;
            this.testName = testName;
            this.dateOfPass = dateOfPass;
            this.result = result;
        }

        /// <summary>
        /// Student name
        /// </summary>
        [DataMember]
        public string studentName;

        /// <summary>
        /// Test name
        /// </summary>
        [DataMember]
        public string testName;

        /// <summary>
        /// Date of delivery
        /// </summary>
        [DataMember]
        public string dateOfPass;

        /// <summary>
        /// Test result
        /// </summary>
        [DataMember]
        public int result;

        public int CompareTo(object obj)
        {
            StudentTestRes anotherSt = obj as StudentTestRes;
            if (this.result > anotherSt.result)
                return 1;
            else if (this.result == anotherSt.result)
                return 0;
            else
                return -1;
        }
    }
}
