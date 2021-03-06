//===============================================================================
// NarolaInfotech Common Support Library
// Core
//===============================================================================
// Copyright � NarolaInfotech.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using NarolaInfotech.Common.Configuration;

namespace NarolaInfotech.Common.Configuration.Manageability.Configuration
{
	/// <summary>
	/// Represents the configuration settings that describe an <see cref="ConfigurationElementManageabilityProvider"/>.
	/// </summary>
	public class ConfigurationElementManageabilityProviderData : NameTypeConfigurationElement
	{
		private const string targetTypePropertyName = "targetType";

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationElementManageabilityProviderData"/> class with default values.
		/// </summary>
		public ConfigurationElementManageabilityProviderData()
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationElementManageabilityProviderData"/> class.
		/// </summary>
		/// <param name="name">The name of the configuration element.</param>
		/// <param name="providerType">The <see cref="ConfigurationElementManageabilityProvider"/> type.</param>
		/// <param name="targetType">The <see cref="NamedConfigurationElement"/> type that is managed by the provider type.</param>
		public ConfigurationElementManageabilityProviderData(String name, Type providerType, Type targetType)
			: base(name, providerType)
		{
			this.TargetType = targetType;
		}

		/// <summary>
		/// Gets or sets the <see cref="NamedConfigurationElement"/> type that is managed by the provider type.
		/// </summary>
		[ConfigurationProperty(targetTypePropertyName, IsRequired = true)]
		[TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]
		public Type TargetType
		{
			get { return (Type)base[targetTypePropertyName]; }
			set { base[targetTypePropertyName] = value; }
		}

		internal ConfigurationElementManageabilityProvider CreateManageabilityProvider()
		{
			return (ConfigurationElementManageabilityProvider)Activator.CreateInstance(this.Type);
		}
	}
}
