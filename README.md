# RedisTest
This project presents basic level redis cache process.
And I used ocelot apigateway for this project but we didn't need apigateway for this project. 

And we have a scenario;

We have a mobile or web application and we would like to change our theme light to dark or dark to light. when we change to other phone or computer and we login with same user to our application  this changes must to be active. If we use the local storage this changes not active for other devices. We might use this new theme in one device.

Therefore we need use the another choices. We might prefer redis for caching mechanism.
If we change our theme and save to redis. This change will be active our devices when we login with same user.
