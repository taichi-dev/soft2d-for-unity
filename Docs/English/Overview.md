# Overview

## Introduction

Soft2D is a 2D multi-material continuum physics engine designed for real-time applications. Soft2D for Unity provides a high-level encapsulation for Soft2D and offers users a range of easy-to-use interfaces, enabling them to easily implement various physical simulations and rendering effects in Unity.

## Prerequisite

- Graphics API: Vulkan or Metal
- Unity version: 2021.3.22f1 or higher
- Render Pipeline: built-in or URP
- Scripting Backend: IL2CPP

## Tutorial

[Detailed tutorials](Tutorials/Tutorial.md)

## Basic Concepts

### Soft2DManager

Soft2DManager is used for creating Soft2D objects and adjusting simulation environment parameters.

[Introduction](BasicComponents/Soft2DManager.md)

### Body

A body is a continuum to be simulated, which is composed of a group of particles.

[Introduction](BasicComponents/Body.md)

### Collider

A collider is an obstacle within the world that blocks the motion of bodies.

[Introduction](BasicComponents/Collider.md)

### Trigger

A trigger is a spatial area with a specific shape, which is able to detect particles passing through it.

[Introduction](BasicComponents/Trigger.md)

### Emitter

An emitter is an object that can continuously emit bodies.

[Introduction](BasicComponents/Emitter.md)

## Advance

[Custom Soft2D Shader](Advance/CustomShader.md)

[Custom Trigger Function](Advance/CustomTrigger.md)

[Debug Tools](Advance/DebugTools.md)
