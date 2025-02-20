using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace BiometricService.Controllers
{
    [ApiController]
    [Route("apiservice/")]
    public class APIController : ControllerBase
    {
        private readonly Biometric _biometric;

        public APIController(Biometric biometric)
        {
            _biometric = biometric;
        }

        [HttpGet("capture-hash")]
        public IActionResult Capture(bool? img)
        {
            if (img.HasValue)
            {
                return _biometric.CaptureHash((bool)img);
            }
            else
            {
                return _biometric.CaptureHash();
            }
        }

        [HttpGet("capture-for-verify")]
        public IActionResult CaptureForVerify(uint? window)
        {
            if (window.HasValue)
            {
                return _biometric.CaptureForVerify((uint)window);
            }
            else
            {
                return _biometric.CaptureForVerify();
            }
        }

        [HttpPost("match-one-on-one")]
        public IActionResult MatchOneOnOne([FromBody] JsonObject template, bool? img)
        {
            if (img.HasValue)
            {
                return _biometric.IdentifyOneOnOne(template, (bool)img);
            }
            else
            {
                return _biometric.IdentifyOneOnOne(template);
            }
        }

        [HttpGet("identification")]
        public IActionResult Identification(uint? secuLevel)
        {
            if (secuLevel.HasValue)
            {
                return _biometric.Identification((uint)secuLevel);
            }
            else
            {
                return _biometric.Identification();
            }
        }

        [HttpPost("load-to-memory")]
        public IActionResult LoadToMemory([FromBody] JsonArray fingers)
        {
            return _biometric.LoadToMemory(fingers);
        }

        [HttpGet("delete-all-from-memory")]
        public IActionResult DeleteAllFromMemory()
        {
            return _biometric.DeleteAllFromMemory();
        }

        [HttpGet("total-in-memory")]
        public IActionResult TotalIdsInMemory()
        {
            return _biometric.TotalIdsInMemory();
        }

        [HttpGet("device-unique-id")]
        public IActionResult DeviceUniqueSerialID()
        {
            return _biometric.DeviceUniqueSerialID();
        }

        [HttpPost("join-templates")]
        public IActionResult JoinTemplates([FromBody] JsonArray fingers)
        {
            return _biometric.JoinTemplates(fingers);
        }
    }
}