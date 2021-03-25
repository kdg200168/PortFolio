package jp.ohtsuki.minigame;

import java.awt.image.BufferedImage;
import java.util.ArrayList;

import javax.sound.sampled.Clip;

public abstract class initScreen extends Key {

	public static final int WIDTH = 640;
	public static final int HEIGHT = 480;
	protected BufferedImage pimage;
	protected BufferedImage eimage;
	protected BufferedImage wimage;
	protected BufferedImage startimage;
	protected Player player;
	@SuppressWarnings("rawtypes")
	protected ArrayList tekis;
	protected Clip clip1;
	protected Clip clip3;
	protected Map map;

	public initScreen(int w, int h, String title) {
		super(w, h, title);
	}

	@SuppressWarnings("rawtypes")
	public void initStageStart() {
		player = new Player(WIDTH/2,HEIGHT/2,pimage);	
		tekis = new ArrayList(); 
		upkey=false;rightkey=false;
		leftkey=false;
		map = new Map(wimage,"map02.map","001.pa");
		
		midiseq.setTickPosition(0);
		midiseq.start();
	}

	public void initStageClear() {
		midiseq.stop();
		clip3.setFramePosition(0);
		clip3.start();
	}

	public void initGameOver() {
		midiseq.stop();
		clip1.setFramePosition(0);
		clip1.start();
	}

}