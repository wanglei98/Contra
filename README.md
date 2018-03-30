# Contra
## Day 1
了解了一下2D的横版射击游戏比较难的点，选择了unity作为游戏的引擎，但在主要完成了背景的添加和人物的加入，参考了一些博客，实现控制人物左右移动，但对于跳动以及卧下还没有很好的解决方法。主要用到的代码为
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	// Use this for initialization
	public Vector2 speed = new Vector2(50,50);

	private Vector2 movement;

	
		

		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY);
		

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
  ```
  rigibody2D在5.X版本经过了修改，使用会变得更加规范一些。在这里把rigibody2D的规范性没用好，通过查询资料明白5.x后的版本都要在rigibody前加个GetComponent。
  
  
## Day 2
  主要是学习了一下，GitHub的用法，了解了一下git的相关知识，并修改了一点第一天里以移动出现的问题。
  学了一点markdown的比较基本的语法。
  
## Day 3
  为游戏中的人物添加了武器，可以射出子弹，且为敌我双方设置了生命，boss尚未涉及，切敌人在触碰了我方的子弹过后会消失
  具体代码在上传的文件HealthScript，WeaponScript中可以看到。
  
## Day 4
  学业繁忙，告辞。
  
## Day 5 
  补上之前的开发日志，以及在琢磨着让敌人能够射出子弹的代码。修改完成能够让敌人射出子弹的代码，然后卡在了如何控制玩家上蹦下跳，已经实现左右移动。

## Day 6
  参考了一下GitHub上的一部分魂斗罗的源码，自己写了一个控制主角实现了俯卧，跳跃，以及向上开枪的功能。但是在跳跃的过程中纯在着一些问题，比如无法精确的控制跳上去之后再落下来在同一水平线上，以及如何实现跳上平台的问题。代码主要在playerScript中。
