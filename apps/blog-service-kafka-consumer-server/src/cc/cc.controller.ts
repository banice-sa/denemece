import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as errors from "../errors";
import { CcService } from "./cc.service";

@swagger.ApiTags("ccs")
@common.Controller("ccs")
export class CcController {
  constructor(protected readonly service: CcService) {}
}
