// Copyright 1998-2013 Epic Games, Inc. All Rights Reserved.
using UnrealBuildTool;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
#if UE_5_0_OR_LATER
using EpicGames.Core;
#else
using Tools.DotNETCommon;
#endif

namespace UnrealBuildTool.Rules
{
public class SubstanceCore : ModuleRules
{
	private string ModulePath
	{
		get { return ModuleDirectory; }
	}

	private string PluginRootPath
	{
		get { return Path.GetFullPath(Path.Combine(ModulePath, "../../")); }
	}

	private string SubstanceIncludePath
	{
		get { return Path.GetFullPath(Path.Combine(PluginRootPath, "Include")); }
	}

	private string ModuleFullPath
	{
		get { return Path.GetFullPath(ModulePath); }
	}

	public SubstanceCore(ReadOnlyTargetRules Target) : base(Target)
	{
		//Internal defines
		PublicDefinitions.Add("WITH_SUBSTANCE=1");
		PublicDefinitions.Add("SUBSTANCE_PLATFORM_BLEND=1");
		PublicDefinitions.Add("SUBSTANCE_CORE_DEBUG_TOOLS=0");

		//PCH file
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
		bEnforceIWYU = true;
		PrivatePCHHeaderFile = "Private/SubstanceCorePrivatePCH.h";

		//Thread usage
		if (Target.IsInPlatformGroup(UnrealPlatformGroup.Microsoft)) // Windows, Xbox
		{
			PublicDefinitions.Add("AIR_USE_WIN32_SYNC=1");
		}
		else if (Target.Platform == UnrealTargetPlatform.Mac ||
		         Target.Platform == UnrealTargetPlatform.Linux)
		{
			PublicDefinitions.Add("AIR_USE_PTHREAD_SYNC=1");
		}

		//Exposing the include path to substance core publicly. Even though the include paths are public, the libs should no longer be exposed.
		PrivateIncludePaths.Add("SubstanceCore/Private");

		//Exposing public include paths
		PublicIncludePaths.Add(Path.Combine(ModuleFullPath, "Public"));
		PublicIncludePaths.Add(Path.Combine(ModuleFullPath, "Classes"));
		PublicIncludePaths.Add(SubstanceIncludePath);

		//Module dependencies
		PrivateDependencyModuleNames.AddRange(new string[]
		{
			"Projects",
			"Slate",
			"SlateCore",
			"SubstanceEngine"
		});

		PublicDependencyModuleNames.AddRange(new string[]
		{
			"AssetRegistry",
			"Core",
			"CoreUObject",
			"Engine",
			"RenderCore",
			"RHI",
			"ImageWrapper",
			"SessionServices",
		});

		if (Target.bBuildEditor == true)
		{
			PublicDependencyModuleNames.AddRange(new string[]
			{
				"UnrealEd",
				"AssetTools",
				"ContentBrowser",
				"Settings",
				"TargetPlatform",
				"MainFrame"
			});
		}
	}
}
}
