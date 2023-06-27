# Material

## Attributes

- Types of Physical Materials
  - Soft2D support types including fluid, sand, elastic and snow.
- Density
  - The object's [density](https://en.wikipedia.org/wiki/Density), which is measured in kilograms per cubic meter (kg/m^3). Common materials such as water have a density of 1000 kg/m^3.
- Young's Modulus
  - The object's [Young's Modulus](https://en.wikipedia.org/wiki/Young%27s_modulus), which is measured in MPa (e.g.  A material similar to jelly, with Young's modulus ranging from approximately 0.01 MPa to 1 MPa).
  - > A larger Young's modulus can cause simulation explosions. In this case, reducing `substep` in Soft2DManager ([Visit Soft2DManager Documentation](../BasicComponents/Soft2DManager.md)) can avoid simulation explosions, but it will significantly reduce simulation performance.
- Poisson's Ratio
  - The object's [Poisson's Ratio](https://en.wikipedia.org/wiki/Poisson%27s_ratio).
- Tag：
  - During initialization, the Body assigns this value to all the particles it contains, so that each particle contained in this Body has this value as its label. In Soft2D, each particle can have its own unique label.
  - Particle tags are mainly used for triggering logical events and rendering. It can be accessed through `S2Particle.tag` (CPU) or `GetParticleTagBuffer()` (GPU).