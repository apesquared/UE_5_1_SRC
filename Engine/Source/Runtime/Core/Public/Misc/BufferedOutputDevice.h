// Copyright Epic Games, Inc. All Rights Reserved.

#pragma once

#include "Containers/Array.h"
#include "CoreTypes.h"
#include "HAL/CriticalSection.h"
#include "Logging/LogVerbosity.h"
#include "Misc/OutputDevice.h"
#include "Misc/OutputDeviceRedirector.h"
#include "UObject/NameTypes.h"

/** Buffered output device. */
class CORE_API FBufferedOutputDevice : public FOutputDevice
{
protected:
	TArray<FBufferedLine>		BufferedLines;
	ELogVerbosity::Type			FilterLevel;
	FCriticalSection			SynchronizationObject;

public:

	FBufferedOutputDevice() : FilterLevel(ELogVerbosity::All)
	{
	}

	void	SetVerbosity(ELogVerbosity::Type Verbosity) { FilterLevel = Verbosity; }
	void	Serialize(const TCHAR* InData, ELogVerbosity::Type Verbosity, const class FName& Category) override;
	void	GetContents(TArray<FBufferedLine>& DestBuffer);

	/** Pushes buffered lines into the specified output device. */
	void RedirectTo(class FOutputDevice& Ar)
	{
		for (const FBufferedLine& BufferedLine : BufferedLines)
		{
			Ar.Serialize(BufferedLine.Data, BufferedLine.Verbosity, BufferedLine.Category);
		}
	}
};

