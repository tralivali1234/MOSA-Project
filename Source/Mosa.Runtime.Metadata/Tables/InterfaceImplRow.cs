/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (grover) <sharpos@michaelruck.de>
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mosa.Runtime.Metadata.Tables
{
	/// <summary>
	/// 
	/// </summary>
	public struct InterfaceImplRow
	{
		#region Data members

		/// <summary>
		/// 
		/// </summary>
		private MetadataToken @class;

		/// <summary>
		/// 
		/// </summary>
		private MetadataToken @interface;

		#endregion // Data members

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="InterfaceImplRow"/> struct.
		/// </summary>
		/// <param name="class">The @class.</param>
		/// <param name="interface">The @interface.</param>
		public InterfaceImplRow(MetadataToken @class, MetadataToken @interface)
		{
			this.@class = @class;
			this.@interface = @interface;
		}

		#endregion // Construction

		#region Properties

		/// <summary>
		/// Gets the class.
		/// </summary>
		/// <value>The class.</value>
		public MetadataToken Class
		{
			get { return this.@class; }
		}

		/// <summary>
		/// Gets the interface.
		/// </summary>
		/// <value>The interface.</value>
		public MetadataToken Interface
		{
			get { return this.@interface; }
		}

		#endregion // Properties
	}
}
