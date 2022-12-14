// Copyright Epic Games, Inc. All Rights Reserved.

using System.Text;
using EpicGames.UHT.Tables;

namespace EpicGames.UHT.Types
{
	/// <summary>
	/// FMulticastInlineDelegateProperty
	/// </summary>
	[UhtEngineClass(Name = "MulticastInlineDelegateProperty", IsProperty = true)]
	public class UhtMulticastInlineDelegateProperty : UhtMulticastDelegateProperty
	{
		/// <inheritdoc/>
		public override string EngineClassName => "MulticastInlineDelegateProperty";

		/// <summary>
		/// Construct new property
		/// </summary>
		/// <param name="propertySettings">Property settings</param>
		/// <param name="function">Referenced function</param>
		public UhtMulticastInlineDelegateProperty(UhtPropertySettings propertySettings, UhtFunction function) : base(propertySettings, function)
		{
		}

		/// <inheritdoc/>
		public override StringBuilder AppendText(StringBuilder builder, UhtPropertyTextType textType, bool isTemplateArgument)
		{
			switch (textType)
			{
				case UhtPropertyTextType.FunctionThunkParameterArgType:
					builder.Append("FMulticastInlineDelegateProperty");
					break;

				default:
					base.AppendText(builder, textType, isTemplateArgument);
					break;
			}
			return builder;
		}

		/// <inheritdoc/>
		public override StringBuilder AppendMemberDecl(StringBuilder builder, IUhtPropertyMemberContext context, string name, string nameSuffix, int tabs)
		{
			return AppendMemberDecl(builder, context, name, nameSuffix, tabs, "FMulticastDelegatePropertyParams");
		}

		/// <inheritdoc/>
		public override StringBuilder AppendMemberDef(StringBuilder builder, IUhtPropertyMemberContext context, string name, string nameSuffix, string? offset, int tabs)
		{
			AppendMemberDefStart(builder, context, name, nameSuffix, offset, tabs, "FMulticastDelegatePropertyParams", "UECodeGen_Private::EPropertyGenFlags::InlineMulticastDelegate");
			AppendMemberDefRef(builder, context, Function, true);
			AppendMemberDefEnd(builder, context, name, nameSuffix);
			return builder;
		}
	}
}
