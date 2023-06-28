# Overview

## Introduction

Soft2D is a 2D multi-material continuum physics engine designed for real-time applications. Soft2D for Unity provides a high-level encapsulation for Soft2D and offers users a range of easy-to-use interfaces, enabling users to easily implement various physical simulations and rendering effects in Unity.

## Prerequisites

|     Unity version    |Graphics API    |   Render Pipeline    | Scripting Backend |
|----------------------|----------------|----------------------|-------------------|
|2021.3.22f1 or higher |Vulkan or Metal |3D built-in or 3D URP |IL2CPP             |


## Installation

- [Download Soft2D for Unity](https://github.com/taichi-dev/soft2d-for-unity/releases/download/v0.1.0/Soft2D.v0.1.0.7z) and unzip it anywhere in your Unity Assets folder (just not inside the Editor, Plugins or Resources directories);
- Click **Run and Restart** button, meanwhile the program will perform the following procedures:
  - Change graphics API to Vulkan or Metal;
  - Change scripting backend to IL2CPP;
  - If the current pipeline is not Universal Render Pipeline, delete files related to it (URP);
  - Restart this project.


- When the rendering pipeline of the imported project is URP: Since the 02_2DGame scene uses Renderer Feature to achieve post-processing effects, you also need the following steps to run the scene normally:
  - Find the **Render Pipeline Asset** currently used by the project under Project Settings -> Rendering -> Render Pipeline Asset.
  - Find RendererList under **Render Pipeline Asset's** Inspector window, click “+” to add a Renderer Data，select **Kawase Blur Data** as new Renderer Data.

## Tutorial

[Detailed tutorials](./Tutorial.md)

## Basic Concepts

### Soft2DManager

Soft2DManager is used for creating Soft2D objects and adjusting simulation environment parameters.

[Introduction](./Soft2DManager.md)

### Body

A body is a continuum to be simulated, which is composed of a group of particles.

[Introduction](./Body.md)

### Collider

A collider is an obstacle within the world that blocks the motion of bodies.

[Introduction](./Collider.md)

### Trigger

A trigger is a spatial area with a specific shape, which is able to detect particles passing through it.

[Introduction](./Trigger.md)

### Emitter

An emitter is an object that can continuously emit bodies.

[Introduction](./Emitter.md)

## Advance

[Custom Soft2D Shader](./CustomShader.md)

[Debug Tools](./DebugTools.md)
