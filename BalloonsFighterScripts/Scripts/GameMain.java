package jp.ohtsuki.minigame;

import java.awt.Color;
import java.io.IOException;

import javax.imageio.ImageIO;

public class GameMain extends RunGame {
	public GameMain() {
		super(WIDTH, HEIGHT, "BalloonsFighter");
		frame1.setBackground(Color.BLACK);
		
		try {
			pimage = ImageIO.read(getClass().getResource("kyara.png"));
			eimage = ImageIO.read(getClass().getResource("UFO.png"));
			wimage = ImageIO.read(getClass().getResource("toge.png"));
			backimage = ImageIO.read(getClass().getResource("pipo-bg003.jpg"));		
			startimage = ImageIO.read(getClass().getResource("title.jpg"));
		} catch (IOException e) {
			e.printStackTrace();
		}
		clip1 = otoYomikomi("se_maoudamashii_retro21.wav");
		clip2 = otoYomikomi("se_maoudamashii_retro08.wav");
		clip3 = otoYomikomi("game_maoudamashii_9_jingle09.mid");
		midiYomikomi("bgm_maoudamashii_8bit17.mp3.mid");
		goStartGamen();
	}

	public static void main(String[] args) {
		@SuppressWarnings("unused")
		GameMain usm = new GameMain();
	}
}
