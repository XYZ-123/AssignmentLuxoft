﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trade.cs" company="">
//   
// </copyright>
// <summary>
//   The trade.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AssignmentLuxoft.Models
{
    using System;

    /// <summary>
    /// The trade.
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// Gets or sets the high.
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// Gets or sets the low.
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// Gets or sets the close.
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        public long Volume { get; set; }
    }
}