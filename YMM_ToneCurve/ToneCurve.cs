using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMM_ToneCurve.Property;
using YMM_ToneCurve.Property.Editor;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace YMM_ToneCurve
{
    [VideoEffect("Tone Curve L", ["加工"], [], IsAviUtlSupported = false)]
    public class ToneCurve : VideoEffectBase
    {
        public override string Label => "Tone Curve L";

        ToneCurveParameters parameters = new ToneCurveParameters(
            [new ToneCurvePoint(0.0F, 0.0F), new ToneCurvePoint(1.0F, 1.0F)],
            [new ToneCurvePoint(0.0F, 0.0F), new ToneCurvePoint(1.0F, 1.0F)],
            [new ToneCurvePoint(0.0F, 0.0F), new ToneCurvePoint(1.0F, 1.0F)],
            [new ToneCurvePoint(0.0F, 0.0F), new ToneCurvePoint(1.0F, 1.0F)],
            [new ToneCurvePoint(0.0F, 0.0F), new ToneCurvePoint(1.0F, 1.0F)]
        );
        [Display(GroupName = "トーンカーブL", Description = "ToneCurveの改造版です。")]
        [ToneCurveParametersEditor(PropertyEditorSize = PropertyEditorSize.FullWidth)]
        public ToneCurveParameters Parameters
        {
            get => parameters;
            set => Set(ref parameters, value);
        }

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return [];
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new ToneCurveProcessor(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables()
        {
            return [];
        }
    }
}
