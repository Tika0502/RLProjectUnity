# 🤖 Unity ML-Agent: Reinforcement Learning Project

> A Reinforcement Learning project built with Unity ML-Agents, developed during sophomore year at the **University of Debrecen** in collaboration with our professor.

---

## 📌 Overview

This project demonstrates the fundamentals of **Reinforcement Learning (RL)** through a trained Unity agent. The agent learns entirely from its own actions — it is rewarded for correct behaviour and punished for incorrect behaviour, gradually building a decision-making "brain" stored in a trained model file.

---

## 🎯 Project Description

A **Cube agent** navigates a surface and attempts to collide with **3 Spheres** placed within the environment.

- Upon successfully colliding with all 3 spheres, the positions of the agent and all objects **randomly respawn** within a defined range `(x, y, z)`.
- This continuous cycle forces the agent to generalize its behaviour rather than memorize fixed paths.

---

## 🛠️ Technologies & Tools

| Category | Tools / Technologies |
|---|---|
| Game Engine | Unity |
| Scripting Language | C# |
| ML Framework | Unity ML-Agents |
| Monitoring | TensorBoard |
| Physics | RigidBody, Colliders |
| Perception | Ray Perception Sensor 3D |
| Scripting Base | MonoBehaviour |

---

## ⚙️ Agent Architecture

The agent is built on a **MonoBehaviour script**, allowing it to make autonomous decisions at each step of the environment.

### Components Used
- **RigidBody** — handles physics-based movement and forces
- **Colliders** — detects collision events with target spheres
- **Ray Perception Sensor 3D** — gives the agent spatial awareness of its surroundings

---

## 📄 Hyperparameters (`.yaml` config)

The following hyperparameters were found to produce the fastest and most stable learning:

```yaml
batch_size: 32
buffer_size: 500
learning_rate: 5.0e-4
```

> These values were tuned through experimentation to strike the best balance between learning speed and training stability.

---

## 📊 TensorBoard Monitoring

Training progress was tracked in real time using **TensorBoard**, observing the following metrics:

- 📈 **Cumulative Reward** — overall performance of the agent over time
- 📉 **Policy Loss** — how much the agent's policy is changing per update
- 🔁 **Learning Rate** — rate at which the model updates its weights
- 🌍 **Environment Metrics** — episode length, success rate, and more
- ⚡ **Training Performance** — speed and efficiency of the training loop

---

## 🚀 Getting Started

### Prerequisites
- [Unity Hub](https://unity.com/download) with Unity **2021.x or later**
- [ML-Agents Release](https://github.com/Unity-Technologies/ml-agents/releases) (`com.unity.ml-agents`)
- Python `3.8+` with `mlagents` installed

```bash
pip install mlagents
```

### Running Training

```bash
mlagents-learn config/agent_config.yaml --run-id=CubeAgent_Run1
```

Then press **Play** in the Unity Editor to begin training.

### Monitoring with TensorBoard

```bash
tensorboard --logdir results
```

---

## 📚 What I Learned

- Implementing a complete RL training loop inside Unity
- Designing reward functions that guide meaningful agent behaviour
- Tuning hyperparameters to improve convergence speed
- Interpreting training metrics through TensorBoard visualizations
- Writing autonomous agent logic in C# using the ML-Agents API

---

## 🙏 Acknowledgements

Special thanks to our professor at the **University of Debrecen, Faculty of Informatics** for guiding us through this project and introducing us to the world of Machine Learning in game environments.

---

## 📬 Contact

**Tilyekbyerdi Khabai**  
📧 ttika729@gmail.com  
📍 Debrecen, Hungary
