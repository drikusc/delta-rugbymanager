namespace RugbyManager.Models
{
    public class ResponseConfiguration
    {
        public int SuccessfulResponseCode { get; set; }

        public string SuccessfulResponseMessage { get; set; }

        public int InvalidStadiumResponseCode { get; set; }

        public string InvalidStadiumResponseMessage { get; set; }

        public int TeamAlreadyExistsCode { get; set; }

        public string TeamAlreadyExistsMessage { get; set; }

        public int InvalidBirthDateFormatCode { get; set; }

        public string InvalidBirthDateFormatMessage { get; set; }

        public int InvalidPositionCode { get; set; }

        public string InvalidPositionMessage { get; set; }

        public int InvalidTeamCode { get; set; }

        public string InvalidTeamMessage { get; set; }

        public int InvalidPlayerCode { get; set; }

        public string InvalidPlayerMessage { get; set; }

        public int StadiumAlreadyHasLinkedTeamCode { get; set; }

        public string StadiumAlreadyHasLinkedTeamMessage { get; set; }

        public int DuplicateStadiumNameCode { get; set; }

        public string DuplicateStadiumNameMessage { get; set; }

        public int ErrorOccuredCode { get; set; }

        public string ErrorOccuredMessage { get; set; }
    }
}