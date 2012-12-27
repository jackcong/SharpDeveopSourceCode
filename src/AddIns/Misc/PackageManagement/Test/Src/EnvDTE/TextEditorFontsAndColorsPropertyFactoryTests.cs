﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.PackageManagement.EnvDTE;
using NUnit.Framework;

namespace PackageManagement.Tests.EnvDTE
{
	[TestFixture]
	public class TextEditorFontsAndColorsPropertyFactoryTests
	{
		TextEditorFontsAndColorsPropertyFactory propertyFactory;
		Properties properties;
		
		void CreateProperties()
		{
			propertyFactory = new TextEditorFontsAndColorsPropertyFactory();
			properties = new Properties(propertyFactory);			
		}
		
		void AssertPropertiesContainProperty(string expectedPropertyName)
		{
			var propertiesList = new List<Property>(properties);
			Property property = propertiesList.Find(p => p.Name == expectedPropertyName);
			Assert.IsNotNull(property, "Unable to find property: " + expectedPropertyName);
		}
		
		[Test]
		public void Item_LocateFontsAndColorsItemsProperty_ReturnsFontsAndColorsItemsProperty()
		{
			CreateProperties();
			
			var property = properties.Item("FontsAndColorsItems") as TextEditorFontsAndColorsItemsProperty;
			string name = property.Name;
			
			Assert.AreEqual("FontsAndColorsItems", name);
		}
		
		[Test]
		public void GetEnumerator_GetAllPropertiesUsingEnumerator_HasFontsAndColorItemsProperty()
		{
			CreateProperties();
			
			AssertPropertiesContainProperty("FontsAndColorsItems");
		}
				
		[Test]
		public void Item_UnknownProperty_ReturnsNull()
		{
			CreateProperties();
			
			Property property = properties.Item("UnknownPropertyName");
			Assert.IsNull(property);
		}
		
		[Test]
		public void Item_LocateFontsAndColorsItemsPropertyInUpperCase_ReturnsFontsAndColorsItemsProperty()
		{
			CreateProperties();
			
			Property property = properties.Item("FONTSANDCOLORSITEMS");
			Assert.IsNotNull(property);
		}
		
		[Test]
		public void Item_LocateFontSizeProperty_ReturnsFontSizeProperty()
		{
			CreateProperties();
			
			var property = properties.Item("FontSize") as TextEditorFontSizeProperty;
			string name = property.Name;
			
			Assert.AreEqual("FontSize", name);
		}
		
		[Test]
		public void Item_LocateFontSizePropertyInUpperCase_ReturnsFontSizeProperty()
		{
			CreateProperties();
			
			Property property = properties.Item("FONTSIZE");
			
			Assert.IsNotNull(property);
		}
		
		[Test]
		public void GetEnumerator_GetAllPropertiesUsingEnumerator_HasFontSizeProperty()
		{
			CreateProperties();
			
			AssertPropertiesContainProperty("FontSize");
		}
	}
}
