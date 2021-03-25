package jp.ohtsuki.minigame;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.util.ArrayList;
import java.util.Iterator;

import javax.sound.sampled.Clip;

public abstract class RunGame extends initScreen {

	protected BufferedImage backimage;
	double vx;
	double vy;
	protected Clip clip2;

	public RunGame(int w, int h, String title) {
		super(w, h, title);
	}

	public void runStartGamen(Graphics g) {
		g.drawImage(startimage,0,0,frame1);
	}

	public void runStageStart(Graphics g) {
		g.setColor(Color.BLACK);
		g.fillRect(0,0,WIDTH,HEIGHT);
		g.setColor(Color.CYAN);
		g.setFont(new Font("SansSerif",Font.BOLD,60));
		drawStringCenter("STAGE",200,g);
		drawStringCenter("START!",280,g);
	}

	public void runStageClear(Graphics g) {
		g.setColor(Color.CYAN);
		g.setFont(new Font("SansSerif",Font.BOLD,60));
		drawStringCenter("StageClear!",200,g);
	}

	@SuppressWarnings({ "unchecked", "rawtypes", "unused" })
	public void runGameMain(Graphics g) {
	// draw background
		g.drawImage(backimage, 0,0, frame1);
		
		// Move operation
	
		if (upkey==true) {
			vy = vy-0.25;
			if(clip2.isRunning()==false){
				clip2.setFramePosition(0);
				clip2.start();
			}
		}else {
			vy = vy+0.25;
		}
	
		if (leftkey==true) {
			vx = vx - 0.25;
			}	
			
	
		if (rightkey==true) {	
			vx = vx + 0.25;
			}
	
		//gravity Fall judgment
		if (vy<-6)	vy = -6;
		if (vy>6)	vy = 6;
		if (vx<-6)	vx = -6;
		if (vx>6)	vx= 6;
		player.chara_y= player.chara_y+(int)vy;
		player.chara_x = player.chara_x+(int)vx;
		if (player.chara_y<0)	player.chara_y= 0;
		if (player.chara_y<0)	player.chara_y = 0;
		if (player.chara_x<0)	player.chara_x=0;
		if (player.chara_x>GameMain.WIDTH-48)	player.chara_x=GameMain.WIDTH-48;
		if (player.chara_y>443)	goGameOver();	
	
		//Appearance
		ArrayList al = map.getNewTeki(eimage);
		if (al.size()>0) tekis.addAll(al);
	
		//drawing deleted
		//draw map 
		map.draw(g,frame1);
		//draw player 
		player.draw(g,frame1);
		// draw teki 
		Iterator it = tekis.iterator();
		while(it.hasNext()==true){
			Teki tk = (Teki)it.next();
			}
		//teki.delete
		it = tekis.iterator();
		while(it.hasNext()==true){
			Teki tk = (Teki)it.next();
			tk.draw(g,frame1);
			if(tk.isSotoNiDeta()==true) it.remove();
		}
	
		//Scene transition
		//Collide with the enemy
		it = tekis.iterator();
		while(it.hasNext()==true){
			Teki tk = (Teki)it.next();
			if(tk.isAtari(player)){
				goGameOver();
				break;
			}
		} 
	
	
		//Collide with the Block
		if(map.isAtari(player.getx1(),player.gety1())==true ||
				map.isAtari(player.getx2(),player.gety2())==true) {
			goGameOver();
		}
	
		// Clearing conditions
		if(map.isMapEnd()==true) 
			goStageClear();
	}

	public void runGameOver(Graphics g) {
		g.setColor(Color.RED);
		g.setFont(new Font("SansSerif",Font.BOLD,80));
		drawStringCenter("GAMEOVER",220,g);
		g.setFont(new Font("SansSerif",Font.PLAIN,24));
		drawStringCenter("RESTART",280,g);
		g.setFont(new Font("SansSerif",Font.PLAIN,24));
		drawStringCenter("PUSH  R  KEY",320,g);
	}

}