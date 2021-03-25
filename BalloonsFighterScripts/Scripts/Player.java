package jp.ohtsuki.minigame;

import java.awt.image.BufferedImage;


/**
 * @author ���[�U�[�P
 *
 * TODO ���̐������ꂽ�^�R�����g�̃e���v���[�g��ύX����ɂ͎��փW�����v:
 * �E�B���h�E - �ݒ� - Java - �R�[�h�E�X�^�C�� - �R�[�h�E�e���v���[�g
 */
public class Player extends GameChara {
	double vy;
	public Player(int x, int y, BufferedImage img) {
		super(x, y, 12, 12, img, 0, 0, 48, 48);
	}

	public void move() {
	}
}