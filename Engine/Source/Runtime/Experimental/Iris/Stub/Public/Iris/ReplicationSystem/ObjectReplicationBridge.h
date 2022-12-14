// Copyright Epic Games, Inc. All Rights Reserved.

#pragma once

#include "ReplicationBridge.h"
#include "ObjectReplicationBridge.generated.h"

// Stub used when we are not compiling with iris to workaround UHT dependencies
static_assert(UE_WITH_IRIS == 0, "IrisStub module should not be used when iris is enabled");

UCLASS(Transient, MinimalApi)
class UObjectReplicationBridge : public UReplicationBridge
{
	GENERATED_BODY()
};
