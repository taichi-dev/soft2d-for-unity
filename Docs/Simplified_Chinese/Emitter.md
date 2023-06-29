# Emitter
Emitter 是一个能自由控制发射 Body 的发射器。对应代码中的 EEmitter 类型。 

## 参数面板
EEmitter 的参数面板分为 Emitter 设置、材质设置、颜色设置、事件设置四个部分。

### Emitter 设置
- 是否在开始时发射
  - 为真时 Emitter 会在 World 生成完毕后就开始发射预设 Body。
- 发射初的线速度
  - 发射 Body 的初始线速度。单位为`米每秒`。
- 发射初的角速度
  - 发射 Body 的初始角速度。单位为`角度每秒`。
- 发射频率
  - 发射 Body 的频率。单位为`数量每秒`。
- 生命周期
  - Body 被发射后自动销毁的时长。单位为`秒`。小于等于0表示永远不会被自动销毁。

- 是否使用 MeshBody
  - 是否让发射器发射 MeshBody。为真时发射器会发射 MeshBody。
- Body 形状
  - 见 [Shape](./Shape.md)。
- MeshBody 设置
  - 见 [Mesh Body](Body.md#mesh-body)。

### 材质设置
见 [Material](./Material.md)。

### 颜色设置
- 基础颜色
  - 发射的 Body 内粒子颜色。关闭随机颜色后可用。
- 随机颜色
  - 是否从随机颜色列表内随机抽取颜色。
- 随机颜色列表
  - 可被抽取的所有颜色集合。打开随机颜色后可用。
- 彩虹模式
  - 是否随机生成 RGB 值作为粒子颜色。

### 事件设置
- OnEmitterOut
  - 发射粒子时自动调用该事件。
