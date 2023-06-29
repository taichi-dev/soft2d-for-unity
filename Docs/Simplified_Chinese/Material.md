# Material
- 物理材质类型
  - 流体、沙子、弹性体或雪。
- 密度
  - 物质的[密度](https://en.wikipedia.org/wiki/Density)，单位为 kg/m^3。常见的材料如水的密度为1000。
- 杨氏模量
  - 物质的[杨氏模量](https://en.wikipedia.org/wiki/Young%27s_modulus)。单位为 MPa。如类似于果冻的材料，其杨氏模量约为 0.01Mpa ~ 1MPa 之间。
  
  > 较大的杨氏模量会导致模拟爆炸。此时降低 Soft2DManager 中的`时间子步长` (见 [Soft2DManager](./Soft2DManager.md)) 可以避免模拟爆炸，但注意过小的`时间子步长`会导致模拟性能下降。
  
  > 流体本身并没有杨式模量这个属性。在本插件中，流体的杨式模量用来表示流体的不可压缩程度。

- 泊松比
  - 物质的[泊松比](https://en.wikipedia.org/wiki/Poisson%27s_ratio)。
- 标签：
  -  Soft2D 中，每个粒子都可以有一个自己的标签。Body 在初始化时将此值赋值给其包含的所有粒子，使得该 body 包含的每个粒子的标签都是此值。
  
  > 粒子标签主要用于 trigger 逻辑事件和渲染，可以通过 `S2Particle.tag` (CPU) 或者 `GetParticleTagBuffer()` (GPU) 进行访问。