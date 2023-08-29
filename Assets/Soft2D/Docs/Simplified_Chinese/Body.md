# Body
Body 是一个可以被模拟的连续体，由一组粒子组成。一个 body 拥有形状（shape）、中心（center）、物理材质（material）等属性。对应代码中的 `EBody` 类型。

## 参数面板

### Body 设置
- 形状
  - Body 的初始形状。根据具体的形状，Soft2D 会自动采样生成在其内部的粒子。目前支持长方形、圆形、椭圆形、胶囊体形和多边形这几种类型。形状的详细文档见 [Shape](./Shape.md)。
- 线速度
  - Body 的初始线速度。单位为`米每秒`。
- 角速度
  - Body 的初始角速度。单位为`角度每秒`。
- 生命周期
  - Body 生成后自动销毁的时长。单位为`秒`。小于等于0表示永远不会被自动销毁。
- 粒子标签
  - Soft2D 中，每个粒子都可以有一个自己的标签。Body 在初始化时将此值赋值给其包含的所有粒子，使得该 body 包含的每个粒子的标签都是此值。
  > 粒子标签主要用于 trigger 逻辑事件和渲染，可以通过 `S2Particle.tag` (CPU) 或者 `GetParticleTagBuffer()` (GPU) 进行访问。

### 材质设置
见 [Material](./Material.md)。

### 颜色设置
- 基础颜色
  - 给予 body 内粒子一个相同的颜色。
- 随机生成颜色
  - 给予 body 内粒子随机生成的颜色。

# 其它类型 Body

## Custom Body
Custom body 是用户指定采样点的 body。用户可以自定义 body 内部的粒子位置。对应代码中的 `ECustomBody` 类型。

### 参数面板

- 粒子局部空间位置
  - CustomBody 内粒子在局部空间的位置。

## Mesh Body
Mesh body 是带有拓扑关系的 body。每个传入网格的顶点位置会生成一个粒子，它们之间遵循网格内三角形的拓扑关系。对应代码中的 `EMeshBody` 类型。

### 参数面板
- 网格
  - 用于生成 mesh body 的 2D 网格。
- 网格缩放
  - 网格的缩放系数。