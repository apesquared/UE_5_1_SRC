// Copyright Epic Games, Inc. All Rights Reserved.

#pragma once

#include "IDetailCustomization.h"
#include "Templates/SharedPointer.h"

class ALandscape;
class IDetailLayoutBuilder;

class FLandscapeUIDetails : public IDetailCustomization
{
public:
	~FLandscapeUIDetails();

	/** Makes a new instance of this detail layout class for a specific detail view requesting it */
	static TSharedRef<IDetailCustomization> MakeInstance();

	/** IDetailCustomization interface */
	virtual void CustomizeDetails( IDetailLayoutBuilder& DetailBuilder ) override;
	/** End IDetailCustomization interface */

private:
	void ToggleCanHaveLayersContent(ALandscape* Landscape);

	/** Use MakeInstance to create an instance of this class */
	FLandscapeUIDetails();
};
