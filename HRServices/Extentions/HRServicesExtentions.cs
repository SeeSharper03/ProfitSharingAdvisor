using HRServices.PerformanceServices;

namespace HRServices.Extentions
{
    public static class HRServicesExtentions
    {
        #region Enums

        /// <summary>Evaluation Rating Description
        /// <para>Provides a description of the EvaluationRating value</para>
        /// </summary>
        public static string ToStringValue(this EvaluationRating rating)
        {
            switch (rating)
            {
                case EvaluationRating.NeedsImprovement:
                    return "Needs Improvement";
                case EvaluationRating.MeetsExpectations:
                    return "Meets Expectations";
                case EvaluationRating.ExceedsExpectations:
                    return "Exceeds Expecations";
                case EvaluationRating.SignficantlyExceedsExpectations:
                    return "Significantly Exceeds Expectations";
            }
            return string.Empty;
        }


        #endregion
    }
}
