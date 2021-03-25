package jp.ohtsuki.minigame;

import java.awt.event.KeyEvent;

public abstract class Key extends GameHoneGumi {

	protected boolean upkey;
	protected boolean rightkey;
	protected boolean leftkey;

	public Key(int w, int h, String title) {
		super(w, h, title);
	}

	public void keyPressedGameMain(int key) {
		if (key==KeyEvent.VK_UP) 	upkey=true;
	
		if (key==KeyEvent.VK_LEFT) 	leftkey=true;
		if (key==KeyEvent.VK_RIGHT) rightkey=true;
	
	}

	public void keyReleasedGameMain(int key) {
		if (key==KeyEvent.VK_UP) 	upkey=false;
	
		if (key==KeyEvent.VK_LEFT) 	leftkey=false;
		if (key==KeyEvent.VK_RIGHT) rightkey=false;
	}

}