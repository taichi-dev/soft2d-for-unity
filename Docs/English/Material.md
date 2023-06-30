# Material
- Material Type
  - Fluid, sand, elastic body, or snow.
- Density
  - The [density](https://en.wikipedia.org/wiki/Density) of the material, measured in `kg/m^3`. Common materials such as water have a density of 1000.
- Young's Modulus
  - The [Young's Modulus](https://en.wikipedia.org/wiki/Young%27s_modulus) of the material. Measured in `MPa`. For materials similar to jelly, the Young's modulus is usually between 0.01Mpa ~ 1MPa.
  
  > A higher Young's modulus may cause simulation explosion. In such cases, reducing the time step of sub-steps in Soft2DManager (see [Soft2DManager](./Soft2DManager.md)) can prevent simulation explosion. However, please note that a very small time step of sub-steps could lead to performance reduction.

  > Fluid itself does not possess a Young's modulus property. In this plugin, the Young's modulus of fluid is used to indicate the incompressibility of the fluid.

- Poisson's Ratio
  - The [Poisson's Ratio](https://en.wikipedia.org/wiki/Poisson%27s_ratio) of the material.