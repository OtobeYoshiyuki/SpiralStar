using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C���[�����삷��X�p�C�����X�^�[
/// </summary>
public class SpiralStar : StarBase
{
    /// <summary>
    /// �L�[���͂��Ǘ�����N���X
    /// </summary>
    private MyAction m_myAction = null;

    /// <summary>
    /// ����GameObject
    /// SpiralStar�̐i�s�������w��
    /// </summary>
    private GameObject m_childArrow = null;

    /// <summary>
    /// �L��StateMachine
    /// </summary>
    private StateMachine<SpiralStar> m_stateMachine = null;

    /// <summary>
    /// SpiralRotation��State
    /// </summary>
    private SpiralRotation m_spiralRotation = null;

    /// <summary>
    /// SpiralMove��State
    /// </summary>
    private SpiralMove m_spiralMove = null;

    /// <summary>
    /// SpiralCollision��State
    /// </summary>
    private SpiralCollision m_spiralCollision = null;

    /// <summary>
    /// �ړ��ʂ��X�J���{����A�j���[�V�����J�[�u
    /// Inspecter����ҏW�ł���悤�ɂ���
    /// </summary>
    [SerializeField]
    private AnimationCurve m_chargeCurve = null;

    /// <summary>
    /// GameObject�ɐݒ肳��Ă���^�O
    /// �萔
    /// </summary>
    public const string SPIRALSTAR_TAG = "Player";

    /// <summary>
    /// Fiver�X�e�[�^�X��key
    /// �萔
    /// </summary>
    public const string FIVER = "Fiver";

    /// <summary>
    /// Boost�X�e�[�^�X��key
    /// �萔
    /// </summary>
    public const string BOOST = "Boost";

    /// <summary>
    /// �_���[�W�̍ŏ����̗�
    /// </summary>
    public const float DAMAGE_MIN_POWER = 30.0f;

    [SerializeField]
    private Blink m_blink = new Blink();

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public SpiralStar():base()
    {
        //SpiralRotation�̃C���X�^���X�𐶐�
        m_spiralRotation = new SpiralRotation();

        //SpiralMove�̃C���X�^���X�𐶐�
        m_spiralMove = new SpiralMove();

        //SpiralCollision�̃C���X�^���X�𐶐�
        m_spiralCollision = new SpiralCollision();
    }

    /// <summary>
    /// �C���X�^���X�̐�������ɌĂ΂�鏈��
    /// </summary>
    private void Awake()
    {
        //�L�[���͂̊Ǘ��N���X�𐶐�
        m_myAction = new MyAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        //SpriteRenderer���擾����
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        //���̏���������
        StarInit();

        //�L��StateMachine�̃C���X�^���X�𐶐�
        m_stateMachine = new StateMachine<SpiralStar>(this, m_spiralRotation);

        for (int i = 0; i < BlackStarFactory.MAX_NUM; i++)
        {
            //�G��Star�̃C���X�^���X�𐶐�
            BlackStarFactory.Instance.CreateBlackStar(this, i);
        }

        //�C�x���g�֐���o�^����
        m_blink.drawEnable = () => sprite.color = Color.yellow;
        m_blink.drawDisable = () => sprite.color = Utility.SetColorAddtive(Color.yellow, Color.red,
            (SpriteRenderer renderer, float alfa) => Utility.SetColorOpacity(renderer, alfa), sprite, 0.5f) ;
        m_blink.resetAction = () => sprite.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        //�_�ł̍X�V����
        m_blink.Update();

        //���̍X�V����
        StarUpdate();

        GameData.AddFloat(gameObject.tag + "X", m_rigidBody2D.position.x);
        GameData.AddFloat(gameObject.tag + "Y", m_rigidBody2D.position.y);

        //GamePad��A�{�^���������ꂽ��
        if (m_myAction.Player.Atack.WasPressedThisFrame())
        {
            //SpiralRotation�ւƈڍs����
            m_stateMachine.ChangeState(m_spiralRotation);
        }

        //�_���[�W���󂯂��Ƃ�
        if (damage)
        {
            //HP�Q�[�W�Ƀ_���[�W��^����
            HpGageUI.Instance.OnGageDamageAnimation(this);

            //�`���[�W�����Z�b�g����
            StarChaegeUI.Instance.OnReset();

            //�_�ł�����������
            m_blink.OnReset();

            //�_�ł��J�n����
            m_blink.blink = true;

            //�t���O�𗎂Ƃ�
            damage = false;
        }

        //�\�����镶�������H����
        StarChaegeUI.Instance.ManufacturingText(this);

        //StateMachine�̍X�V����
        m_stateMachine.UpdateState();
    }

    /// <summary>
    /// Object���L���ɂȂ����Ƃ��ɌĂ΂�鏈��
    /// </summary>
    private void OnEnable()
    {
        //�L�[���͂�L���ɂ���
        m_myAction.Enable();
    }

    /// <summary>
    /// Object���������ɂȂ����Ƃ��ɌĂ΂�鏈��
    /// </summary>
    private void OnDisable()
    {
        //�L�[���͂𖳌��ɂ���
        m_myAction.Disable();
    }

    /// <summary>
    /// StateMachine���擾
    /// �Q�b�^�[
    /// </summary>
    public StateMachine<SpiralStar> stateMachine { get { return m_stateMachine; } }

    /// <summary>
    /// SpiralRotation��State���擾
    /// �Q�b�^�[
    /// </summary>
    public SpiralRotation spiralRotation { get { return m_spiralRotation; } }

    /// <summary>
    /// SpiralMove��State���擾
    /// �Q�b�^�[
    /// </summary>
    public SpiralMove spiralMove { get { return m_spiralMove; } }

    /// <summary>
    /// SpiralCollision��State���擾
    /// �Q�b�^�[
    /// </summary>
    public SpiralCollision spiralCollision { get { return m_spiralCollision; } }

    /// <summary>
    /// ����GameObject
    /// �Q�b�^�[�A�Z�b�^�[
    /// </summary>
    public GameObject arrow { get { return m_childArrow; } set { m_childArrow = value; } }

    /// <summary>
    /// �L�[���͂��擾
    /// �Q�b�^�[
    /// </summary>
    public MyAction actions { get { return m_myAction; } }

    /// <summary>
    /// �`���[�W��AnimationCurve���擾
    /// �Q�b�^�[
    /// </summary>
    public AnimationCurve curve { get { return m_chargeCurve; } }

    /// <summary>
    /// �_�ł̏�Ԃ��擾
    /// �Q�b�^�[
    /// </summary>
    public Blink blink { get { return m_blink; } }

    /// <summary>
    /// ���������u�Ԃ����m����
    /// </summary>
    /// <param name="collision">���������I�u�W�F�N�g�̏��</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //BlackStar�ɏՓ˂����ꍇ
        if(collision.gameObject.tag == BlackStar.BLACKSTAR_TAG)
        {
            //StarChargeUI���擾����
            StarChaegeUI starChaegeUI = StarChaegeUI.Instance;

            //StatusManager���擾����
            StatusManager statusManager = StatusManager.Instance;

           //�A�^�b�`����Ă���X�N���v�g���擾����
            BlackStar blackStar = collision.gameObject.GetComponent<BalanStar>();

            //���g���U�����̎�(�`���[�W���̎��͋N�����Ȃ�)
            if (m_stateMachine.currentState == m_spiralMove)
            {
                //���g�̃p���[���K��l�ȏ�̏ꍇ
                if (starChaegeUI.power >= DAMAGE_MIN_POWER)
                {
                    //�G��|��
                    blackStar.deth = true;
                }
                //�p���[������Ȃ��Ƃ�
                else
                {
                    //�_���[�W���󂯂Ă��Ȃ��Ƃ�
                    if (!m_blink.blink)
                    {
                        //�������_���[�W���󂯂�
                        damage = true;

                        //�_���[�W�v�Z���s��
                       statusManager.OnDamageStatus(statusCs, blackStar.statusCs);
                    }
                }
            }
            else
            {
                //���g���`���[�W���̎�
                if (m_stateMachine.currentState == m_spiralRotation)
                {
                    //�_���[�W���󂯂Ă��Ȃ��Ƃ�
                    if (!m_blink.blink)
                    {
                        //�������Ń_���[�W���󂯂�
                        damage = true;

                        //�_���[�W�v�Z���s��
                        statusManager.OnDamageStatus(statusCs, blackStar.statusCs);
                    }
                }
            }
        }
    }
}
