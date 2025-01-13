Hi there!

During our sophomore year at the University of Debrecen, we had the chance to work with our professor to create our very first Unity ML-Agent Project!

The project solely focuses on the actions of the Agent which is basically a Machine that learns with Reinforcement Learning.
Reinforcement Learning is rewarding or punishing the agent based on its decision so that it can process and learn from its actions and store them on a file and create a brain for itself!

About my Project:

I implemented a Cube agent which moves around a surface to collide with 3 Spheres.
When it successfully collides with 3 Spheres the local location of the agent and each objects randomly spawn within a set range(x, y, z).
I used RigidBody, Colliders, Ray Perception Sensor 3D inside Unity and wrote a code for the actions of the Agent in C#.
The Agent uses MonoBehaviour Script as it is purposed to make a decision by itself.
To accelerate the capability of the Agent to learn I used .yaml file where we can change the hyperparameters:
batch_size: 32
buffer_size: 500
learning_rate: 5.0e-4 -> these hyperparameters were the fittest one to accelerate the learning-speed of the Agent.

To observe the Training of the Agent, we used Tensorboard to watch them on Graph such as:
- Cumulative Reward
- Policy loss
- Learning Rate
- Environment Metrics
- Training Performance

I am proud and greatful to implement such a challenging Project which helped me to increase my knowledge and bring a siginificant development for my career.
