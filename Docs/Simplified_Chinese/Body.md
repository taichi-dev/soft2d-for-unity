# Body

Body 是一个可以被模拟的连续体，由一组粒子组成。一个 body 拥有 shape, center, material 等属性。对应代码中的 EBody 类型。

## 使用 Body GameObject 的方法

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/6922f3a3-71bb-4118-97e9-0baa2d80e945

## 参数面板

Body 的参数面板分为 Body 设置、材质设置、颜色设置三个部分。

### Body 设置

- 形状
  - Body 的初始形状。根据具体的形状，Soft2D 会自动采样生成在其内部的粒子。目前支持 box / circle / ellipse / capsule / polygon 这几种类型。
  - 形状的详细文档见： [Shape.md](./Shape.md)
- 线速度
  - Body 的初始线速度。单位为 m/s。
- 角速度
  - Body 的初始角速度。单位为角度/s。
- 生命周期
  - Body 生成后自动销毁的时长。单位为 s 。小于等于0表示永远不会被自动销毁。

### 材质设置

[Material](./Material.md)

### 颜色设置

- 基础颜色
  - 给予 Body 内粒子的颜色。
- 随机生成颜色
  - 给予 Body 内粒子随机生成的颜色。

# 其它类型 Body

## CustomBody

CustomBody 是用户指定采样点的 Body。对应代码中的 ECustomBody 类型。

### 使用 CustomBody GameObject 的方法

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/bcb8d860-8435-4a33-832a-618c5eb4dff6

### 参数面板

- 粒子局部空间位置
  - CustomBody 内粒子在局部空间的位置。

## MeshBody

MeshBody 是带有拓扑关系的 Body。每个传入网格的顶点位置会生成一个 Soft2D 粒子，它们之间遵循网格内三角形的拓扑关系。对应代码中的 EMeshBody 类型。

### 使用 MeshBody GameObject 的方法

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/a9a608d9-a5b5-4927-96e4-c20d4e9b1d6c

### 参数面板

- 网格
  - MeshBody 对应的网格
- 网格缩放
  - 对应网格生成 MeshBody 的缩放系数