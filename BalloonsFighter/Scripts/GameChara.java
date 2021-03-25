
package jp.ohtsuki.minigame;

import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.awt.image.ImageObserver;


public abstract class GameChara {
	public static final int AREA_X1 = -48;
	public static final int AREA_Y1 = -48;
	public static final int AREA_X2 = initScreen.WIDTH+48;
	public static final int AREA_Y2 = initScreen.HEIGHT+48;
		
	public int chara_x, chara_y;
	int image_x, image_y, image_w, image_h;
	int atari_w, atari_h;
	BufferedImage image1;
	
	GameChara(int x,int y, int aw,int ah, BufferedImage img,
			int ix,int iy, int iw,int ih){
		chara_x=x;	chara_y=y;
		atari_w=aw;	atari_h=ah;
		image1=img;	
		image_x=ix;	image_y=iy;	image_w=iw;	image_h=ih;
	}

	public void draw(Graphics g,ImageObserver io){
		g.drawImage(image1, chara_x, chara_y, chara_x+image_w, chara_y+image_h,
				image_x, image_y, image_x+image_w, image_y+image_h, io);
		move();
	}

	public abstract void move();
	
	public int getx1(){
		return chara_x+(image_w-atari_w)/2;
	}
	public int gety1(){
		return chara_y+(image_h-atari_h)/2;
	}
	public int getx2(){
		return chara_x+(image_w+atari_w)/2;
	}
	public int gety2(){
		return chara_y+(image_h+atari_h)/2;
	}
	
	public boolean isAtari(GameChara aite){
		if( aite.getx2()>getx1() && getx2()>aite.getx1() &&
				aite.gety2()>gety1() && gety2()>aite.gety1() ){
			return true;
		} else {
			return false;
		}
	}
	
	public boolean isSotoNiDeta(){
		if ( chara_x<AREA_X1 || chara_y<AREA_Y1 ||
				chara_x+image_w>AREA_X2 || 	chara_y+image_w>AREA_Y2 ){
			return true;
		} else {
			return false;
		}
	}
}
