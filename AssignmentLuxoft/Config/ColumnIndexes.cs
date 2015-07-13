// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnIndexes.cs" company="">
//   
// </copyright>
// <summary>
//   The column indexes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;

namespace AssignmentLuxoft.Config
{
    /// <summary>
    /// The column indexes.
    /// </summary>
    public static class ColumnIndexes
    {
        /// <summary>
        /// The date.
        /// </summary>
        public static readonly int Date = Convert.ToInt32(ConfigurationManager.AppSettings["DateColumnIndex"]);

        /// <summary>
        /// The open.
        /// </summary>
        public static readonly int Open = Convert.ToInt32(ConfigurationManager.AppSettings["OpenColumnIndex"]);

        /// <summary>
        /// The high.
        /// </summary>
        public static readonly int High = Convert.ToInt32(ConfigurationManager.AppSettings["HighColumnIndex"]);

        /// <summary>
        /// The low.
        /// </summary>
        public static readonly int Low = Convert.ToInt32(ConfigurationManager.AppSettings["LowColumnIndex"]);

        /// <summary>
        /// The close.
        /// </summary>
        public static readonly int Close = Convert.ToInt32(ConfigurationManager.AppSettings["CloseColumnIndex"]);

        /// <summary>
        /// The volume.
        /// </summary>
        public static readonly int Volume = Convert.ToInt32(ConfigurationManager.AppSettings["VolumeColumnIndex"]);
    }
}