namespace Task4
{
    using Directum_laba;

    /// <summary>
    /// Класс-встреча, содержащий тип встречи.
    /// </summary>
    public class MeetingWithType : Meeting
    {
        /// <summary>
        /// Конструктор для встречи.
        /// </summary>
        /// <param name="type">Тип встречи.</param>
        public MeetingWithType(MeetingType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Перечисление, хранящее тип встречи
        /// </summary>
        public enum MeetingType
        {
            /// <summary>
            /// Тип - совещание.
            /// </summary>
            Session,

            /// <summary>
            /// Тип - поручение.
            /// </summary>
            Instruction,

            /// <summary>
            /// Тип - телефонный звонок.
            /// </summary>
            PhoneCall,

            /// <summary>
            /// Тип - день рождения.
            /// </summary>
            BirthDay
        }

        /// <summary>
        /// Тип встречи.
        /// </summary>
        public MeetingType Type { get; set; }  
    }
}
